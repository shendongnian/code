    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Mono.Cecil;
    using Mono.Cecil.Rocks;
    namespace Utilities
    {
        public class EmitFactoriesAttribute : Attribute
        {
            public readonly Type[] Types;
            public EmitFactoriesAttribute()
            {
            }
            public EmitFactoriesAttribute(params Type[] types)
            {
                Types = types;
            }
        }
        public class MagicPropertyAttribute : Attribute
        {
        }
        public static class EmitFactories
        {
            public static void WorkOnAssembly(string path)
            {
                AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly("ConsoleApplication4.exe");
                ModuleDefinition module = assembly.MainModule;
                TypeDefinition emitFactoriesAttribute = module.Import(typeof(EmitFactoriesAttribute)).Resolve();
                TypeDefinition magicPropertyAttribute = module.Import(typeof(MagicPropertyAttribute)).Resolve();
                foreach (TypeDefinition type in module.Types)
                {
                    CustomAttribute emitFactory = type.CustomAttributes.SingleOrDefault(x => x.AttributeType.MetadataToken == emitFactoriesAttribute.MetadataToken);
                    if (emitFactory == null)
                    {
                        continue;
                    }
                    TypeReference typeRef = type;
                    TypeReference[] replacementTypes;
                    if (emitFactory.ConstructorArguments.Count != 0)
                    {
                        var temp = ((CustomAttributeArgument[])emitFactory.ConstructorArguments[0].Value);
                        replacementTypes = Array.ConvertAll(temp, x => (TypeReference)x.Value);
                    }
                    else
                    {
                        replacementTypes = new TypeReference[0];
                    }
                    if (replacementTypes.Length != type.GenericParameters.Count)
                    {
                        throw new NotSupportedException();
                    }
                    if (replacementTypes.Length != 0)
                    {
                        typeRef = typeRef.MakeGenericInstanceType(replacementTypes);
                    }
                    foreach (PropertyDefinition prop in type.Properties)
                    {
                        CustomAttribute magicProperty = prop.CustomAttributes.SingleOrDefault(x => x.AttributeType.MetadataToken == magicPropertyAttribute.MetadataToken);
                        if (magicProperty == null)
                        {
                            continue;
                        }
                        MethodReference getter = prop.GetMethod;
                        MethodReference setter = prop.SetMethod;
                        if (replacementTypes.Length != 0)
                        {
                            if (getter != null)
                            {
                                getter = getter.MakeHostInstanceGeneric(replacementTypes);
                            }
                            if (setter != null)
                            {
                                setter = setter.MakeHostInstanceGeneric(replacementTypes);
                            }
                        }
                    }
                }
            }
        }
        public static class TypeReferenceExtensions
        {
            // http://stackoverflow.com/a/16433452/613130
            public static MethodReference MakeHostInstanceGeneric(this MethodReference self, params TypeReference[] arguments)
            {
                var reference = new MethodReference(self.Name, self.ReturnType, self.DeclaringType.MakeGenericInstanceType(arguments))
                {
                    HasThis = self.HasThis,
                    ExplicitThis = self.ExplicitThis,
                    CallingConvention = self.CallingConvention
                };
                foreach (var parameter in self.Parameters)
                    reference.Parameters.Add(new ParameterDefinition(parameter.ParameterType));
                foreach (var generic_parameter in self.GenericParameters)
                    reference.GenericParameters.Add(new GenericParameter(generic_parameter.Name, reference));
                return reference;
            }
        }
        // Test
        [EmitFactories(typeof(int), typeof(long))]
        public class Class<TKey, TValue>
        {
            [MagicProperty]
            Dictionary<TKey, TValue> Property1 { get; set; }
            [MagicProperty]
            List<TValue> Property2 { get; set; }
        }
    }
