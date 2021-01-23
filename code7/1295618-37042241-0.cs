    if (SingleprojectDS.ProjectCustomFields.Select("MD_PROP_UID = '" + CFGuid + "'").Length == 0)
                    {
                        ProjectDataSet.ProjectCustomFieldsRow FunctionCFRow = ProjDS.ProjectCustomFields.NewProjectCustomFieldsRow();
                        FunctionCFRow.PROJ_UID = ProjectGuid;
                        FunctionCFRow.MD_PROP_UID = CFGuid;
                        FunctionCFRow.CUSTOM_FIELD_UID = Guid.NewGuid();
                        FunctionCFRow.TEXT_VALUE = Value;
                        ProjDS.ProjectCustomFields.AddProjectCustomFieldsRow(FunctionCFRow);
                    }
