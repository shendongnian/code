    public class AssembyAwareSurrogateProvider: IDataContractSurrogate
    {
      [DataContract]
      class AssemblyAwareSurrogate
      {
        [DataMember]
        public string AssemblyName { get; set; }
        [DataMember]
        public string TypeName { get; set; }
        [DataMember]
        public byte[ ] Object { get; set; }
        public AssemblyAwareSurrogate( object obj )
        {
          this.AssemblyName = obj.GetType( ).Assembly.FullName;
          this.TypeName = obj.GetType( ).FullName;
          var serializer = new DataContractSerializer( obj.GetType( ) );
          using ( var stream = new MemoryStream( ) )
          {
            serializer.WriteObject( stream, obj );
            stream.Flush( );
            Object = stream.ToArray( );
          }
        }
      }
      public Type GetDataContractType( Type type )
      {
        if ( SatisifesConstraints( type ) ) return typeof( AssemblyAwareSurrogate );
        return type;
      }
      private bool SatisifesConstraints( Type type )
      {
        //--> er - whatever types you're insterested in...
        return type != typeof( AssemblyAwareSurrogate );
      }
      public object GetDeserializedObject( object obj, Type targetType )
      {
        var surrogate = obj as AssemblyAwareSurrogate;
        if ( surrogate != null )
        {
          var assy = Assembly.Load( new AssemblyName( surrogate.AssemblyName ) );
          var serializer = new DataContractSerializer( assy.GetType( surrogate.TypeName ) );
          using ( var stream = new MemoryStream( surrogate.Object ) )
          {
            return serializer.ReadObject( stream );
          }
        }
        return obj;
      }
      public object GetObjectToSerialize( object obj, Type targetType )
      {
        if ( SatisifesConstraints( obj.GetType( ) ) )
        {
          return new AssemblyAwareSurrogate( obj );
        }
        return obj;
      }
      public object GetCustomDataToExport( Type clrType, Type dataContractType )
      {
        return null;
      }
      public object GetCustomDataToExport( MemberInfo memberInfo, Type dataContractType )
      {
        return null;
      }
      public void GetKnownCustomDataTypes( Collection<Type> customDataTypes )
      {
        throw new NotImplementedException( );
      }
      public Type GetReferencedTypeOnImport( string typeName, string typeNamespace, object customData )
      {
        throw new NotImplementedException( );
      }
      public CodeTypeDeclaration ProcessImportedType( CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit )
      {
        throw new NotImplementedException( );
      }
    }
