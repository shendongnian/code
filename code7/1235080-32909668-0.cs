    using Autofac;
    using System.Linq;
    
    // Simple interface just used to prove out the
    // dependency chain that gets resolved.
    public interface IDependencyChain
    {
      IEnumerable<Type> DependencyChain { get; }
    }
    
    // File reading interfaces
    public interface IReadDataFileContents : IDependencyChain { }
    public interface IReadCoreData : IDependencyChain { }
    public interface IReadAdditionalData : IDependencyChain { }
    public interface INormalizeName : IDependencyChain { }
    public interface IAdditionalNameRegex : IDependencyChain { }
    
    // File reading implementations
    public class ReadDataFileContents : IReadDataFileContents
    {
      private readonly IReadCoreData _coreReader;
      private readonly IReadAdditionalData _additionalReader;
      public ReadDataFileContents(IReadCoreData coreReader, IReadAdditionalData additionalReader)
      {
        this._coreReader = coreReader;
        this._additionalReader = additionalReader;
      }
    
      public IEnumerable<Type> DependencyChain
      {
        get
        {
          yield return this.GetType();
          foreach(var t in this._coreReader.DependencyChain)
          {
            yield return t;
          }
          foreach(var t in this._additionalReader.DependencyChain)
          {
            yield return t;
          }
        }
      }
    }
    
    public class ReadDataFileContentsV2 : ReadDataFileContents
    {
      public ReadDataFileContentsV2(IReadCoreData coreReader, IReadAdditionalData additionalReader)
        : base(coreReader, additionalReader)
      {
      }
    }
    
    public class ReadCoreData : IReadCoreData
    {
      public IEnumerable<Type> DependencyChain
      {
        get
        {
          yield return this.GetType();
        }
      }
    }
    
    public class ReadAdditionalData : IReadAdditionalData
    {
      private readonly INormalizeName _normalizer;
      public ReadAdditionalData(INormalizeName normalizer)
      {
        this._normalizer = normalizer;
      }
    
      public IEnumerable<Type> DependencyChain
      {
        get
        {
          yield return this.GetType();
          foreach(var t in this._normalizer.DependencyChain)
          {
            yield return t;
          }
        }
      }
    }
    
    public class ReadAdditionalDataV2 : ReadAdditionalData
    {
      public ReadAdditionalDataV2(INormalizeName normalizer)
        : base(normalizer)
      {
      }
    }
    
    public class ReadAdditionalDataV3 : ReadAdditionalDataV2
    {
      public ReadAdditionalDataV3(INormalizeName normalizer)
        : base(normalizer)
      {
      }
    }
    
    public class NormalizeName : INormalizeName
    {
      public IEnumerable<Type> DependencyChain
      {
        get
        {
          yield return this.GetType();
        }
      }
    }
    
    public class NormalizeNameV2 : INormalizeName
    {
      public readonly IAdditionalNameRegex _nameRegex;
      public NormalizeNameV2(IAdditionalNameRegex nameRegex)
      {
        this._nameRegex = nameRegex;
      }
    
      public IEnumerable<Type> DependencyChain
      {
        get
        {
          yield return this.GetType();
          foreach(var t in this._nameRegex.DependencyChain)
          {
            yield return t;
          }
        }
      }
    }
    
    public class AdditionalNameRegex : IAdditionalNameRegex
    {
      public IEnumerable<Type> DependencyChain
      {
        get
        {
          yield return this.GetType();
        }
      }
    }
    
    public class AdditionalNameRegexV3 : AdditionalNameRegex { }
    
    // File definition modules - each one registers just the overrides needed
    // for the upgraded version of the file type. ModuleV1 registers the base
    // stuff that will be used if things aren't overridden. If any version
    // of a file format needs to "revert back" to an old mechanism, like if
    // V2 needs NormalizeNameV2 and V3 needs NormalizeName, you'd have to re-register
    // the base NormalizeName in the V3 module - override the override.
    public class ModuleV1 : Module
    {
      protected override void Load(ContainerBuilder builder)
      {
        builder.RegisterType<ReadDataFileContents>().As<IReadDataFileContents>();
        builder.RegisterType<ReadCoreData>().As<IReadCoreData>();
        builder.RegisterType<ReadAdditionalData>().As<IReadAdditionalData>();
        builder.RegisterType<NormalizeName>().As<INormalizeName>();
      }
    }
    
    public class ModuleV2 : Module
    {
      protected override void Load(ContainerBuilder builder)
      {
        builder.RegisterType<ReadDataFileContentsV2>().As<IReadDataFileContents>();
        builder.RegisterType<ReadAdditionalDataV2>().As<IReadAdditionalData>();
        builder.RegisterType<NormalizeNameV2>().As<INormalizeName>();
        builder.RegisterType<AdditionalNameRegex>().As<IAdditionalNameRegex>();
      }
    }
    
    public class ModuleV3 : Module
    {
      protected override void Load(ContainerBuilder builder)
      {
        builder.RegisterType<ReadAdditionalDataV3>().As<IReadAdditionalData>();
        builder.RegisterType<AdditionalNameRegexV3>().As<IAdditionalNameRegex>();
      }
    }
    
    // Something has to know about how file formats are put together - a
    // factory of some sort. Here's the thing that "knows." You could probably
    // drive this from config or something else, too, but the idea holds.
    public class FileReaderFactory
    {
      private readonly ILifetimeScope _scope;
      public FileReaderFactory(ILifetimeScope scope)
      {
        // You can always resolve the current lifetime scope as a parameter.
        this._scope = scope;
      }
    
      public IReadDataFileContents CreateReader(int version)
      {
        using(var readerScope = this._scope.BeginLifetimeScope(b => RegisterFileFormat(b, version)))
        {
          return readerScope.Resolve<IReadDataFileContents>();
        }
      }
    
      private static void RegisterFileFormat(ContainerBuilder builder, int version)
      {
        switch(version)
        {
          case 1:
            builder.RegisterModule<ModuleV1>();
            break;
          case 2:
            builder.RegisterModule<ModuleV1>();
            builder.RegisterModule<ModuleV2>();
            break;
          case 3:
          default:
            builder.RegisterModule<ModuleV1>();
            builder.RegisterModule<ModuleV2>();
            builder.RegisterModule<ModuleV3>();
            break;
        }
      }
    }
    
    
    // Only register the factory and other common dependencies - not the file
    // format readers. The factory will be responsible for managing the readers.
    // Note that since readers do resolve from a child of the current lifetime
    // scope, they can use common dependencies that you'd register in the
    // container.
    var builder = new ContainerBuilder();
    builder.RegisterType<FileReaderFactory>();
    var container = builder.Build();
    using(var scope = container.BeginLifetimeScope())
    {
      var factory = scope.Resolve<FileReaderFactory>();
    
      for(int i = 1; i <=3; i++)
      {
        Console.WriteLine("Version {0}:", i);
        var reader = factory.CreateReader(i);
        foreach(var t in reader.DependencyChain)
        {
          Console.WriteLine("* {0}", t);
        }
      }
    }
