        Unable to generate the model because of the following exception: 'System.Data.StrongTypingException: The value for column 'IsPrimaryKey' in table 'TableDetails' is DBNull. ---> System.InvalidCastException: Specified cast is not valid.
        at Microsoft.Data.Entity.Design.VersioningFacade.ReverseEngineerDb.SchemaDiscovery.TableDetailsRow.get_IsPrimaryKey()
        --- End of inner exception stack trace ---
        at Microsoft.Data.Entity.Design.VersioningFacade.ReverseEngineerDb.SchemaDiscovery.TableDetailsRow.get_IsPrimaryKey()
        at Microsoft.Data.Entity.Design.VersioningFacade.ReverseEngineerDb.StoreModelBuilder.CreateProperties(IList`1 columns, IList`1 errors, List`1& keyColumns, List`1& excludedColumns, List`1& invalidKeyTypeColumns)
        at Microsoft.Data.Entity.Design.VersioningFacade.ReverseEngineerDb.StoreModelBuilder.CreateEntityType(IList`1 columns, Boolean& needsDefiningQuery)
        at Microsoft.Data.Entity.Design.VersioningFacade.ReverseEngineerDb.StoreModelBuilder.CreateEntitySets(IEnumerable`1 tableDetailsRows, EntityRegister entityRegister, IList`1 entitySetsForReadOnlyEntityTypes, DbObjectType objectType)
        at Microsoft.Data.Entity.Design.VersioningFacade.ReverseEngineerDb.StoreModelBuilder.CreateEntitySets(IEnumerable`1 tableDetailsRowsForTables, IEnumerable`1 tableDetailsRowsForViews, EntityRegister entityRegister)
        at Microsoft.Data.Entity.Design.VersioningFacade.ReverseEngineerDb.StoreModelBuilder.Build(StoreSchemaDetails storeSchemaDetails)
        at Microsoft.Data.Entity.Design.VisualStudio.ModelWizard.Engine.ModelGenerator.CreateStoreModel()
        at Microsoft.Data.Entity.Design.VisualStudio.ModelWizard.Engine.ModelGenerator.GenerateModel(List`1 errors)
        at Microsoft.Data.Entity.Design.VisualStudio.ModelWizard.Engine.ModelBuilderEngine.GenerateModels(String storeModelNamespace, ModelBuilderSettings settings, List`1 errors)
        at Microsoft.Data.Entity.Design.VisualStudio.ModelWizard.Engine.ModelBuilderEngine.GenerateModel(ModelBuilderSettings settings, IVsUtils vsUtils, ModelBuilderEngineHostContext hostContext)'.
