    using System;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Data.Entity;
    using System.Data.EntityClient;
    using System.Data.Entity.Design;
    using System.Data.Entity.Infrastructure;
    
    namespace DynamicOrm1
    {
        class Generators
        {
            internal EntityModelSchemaGenerator Models { get; set; }
            internal EntityClassGenerator Classes { get; set; }
            internal EntityCodeGenerator Code { get; set; }
            internal EntityViewGenerator Views { get; set; }
            internal EntityStoreSchemaGenerator Store { get; set; }
    
            const string connectionString = "Server = MSSQL2014; Database = test.shop; Trusted_Connection = True;";
            const string providerInvariantName = "System.Data.SqlClient";
    
            public Generators()
            {
                InitializeSettings();
            }
    
            private void InitializeSettings()
            {
                Classes = new EntityClassGenerator(LanguageOption.GenerateCSharpCode);
                Code = new EntityCodeGenerator(LanguageOption.GenerateCSharpCode);
                Views = new EntityViewGenerator(LanguageOption.GenerateCSharpCode);
                Store = new EntityStoreSchemaGenerator(providerInvariantName, connectionString, "ShoppingModelStore");
    
                Store.GenerateForeignKeyProperties = true;
            }
    
            internal void CreateSsdlFile(string filePath)
            {
                if (filePath == String.Empty)
                    throw new Exception("Can't create the SSDL file, because the given file path is an empty string.");
    
                Store.GenerateStoreMetadata();
                Store.WriteStoreSchema(filePath);
            }
    
            internal void CreateCsdlAndMslFile(string csdlFilePath, string mslFilePath)
            {
                if (Store == null)
                    throw new Exception("Can't create the CSDL and MSL files, because the `Store` object is null.");
    
                Models = new EntityModelSchemaGenerator(Store.StoreItemCollection, "ShoppingModelConceptual", "ShoppingModelConceptualContainer");
                Models.GenerateMetadata();
                Models.WriteModelSchema(csdlFilePath);
                Models.WriteStorageMapping(mslFilePath);
            }
        }
    
        class Program
        {
            private static Generators EntityGenerators { get; set; }
    
            [STAThread]
            static void Main()
            {
                try
                {
                    EntityGenerators = new Generators();
                    EntityGenerators.CreateSsdlFile(@"\shopping.ssdl.xml");
                    EntityGenerators.CreateCsdlAndMslFile(@"\shopping.csdl.xml", @"\shopping.msl.xml");
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
