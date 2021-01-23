            // Look for for softdeletes delete.
            var deleteCommand = interceptionContext.OriginalResult as DbDeleteCommandTree;
            if (deleteCommand != null)
            {
                var columnName =
                    SoftDeleteAttribute.GetSoftDeleteColumnName(deleteCommand.Target.Variable.ResultType.EdmType);
                if (columnName != null)
                {
                    // If the IsDeleted property is on this class, then change the delete to an update,
                    // otherwise suppress the whole delete command somehow?
                    var tt = (EntityType) deleteCommand.Target.Variable.ResultType.EdmType;
                    if (
                        tt.DeclaredMembers.Any(
                            m => m.Name.Equals(columnName, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        var setClause =
                            DbExpressionBuilder.SetClause(
                                deleteCommand.Target.VariableType.Variable(deleteCommand.Target.VariableName)
                                    .Property(columnName), DbExpression.FromBoolean(true));
                        var update = new DbUpdateCommandTree(deleteCommand.MetadataWorkspace,
                            deleteCommand.DataSpace,
                            deleteCommand.Target,
                            deleteCommand.Predicate,
                            new List<DbModificationClause> {setClause}.AsReadOnly(), null);
                        interceptionContext.Result = update;
                    }
                    else
                    {
                        interceptionContext.Result = CreateNullFunction(deleteCommand.MetadataWorkspace,
                            deleteCommand.DataSpace);
                    }
                }
            }
        }
        private DbFunctionCommandTree CreateNullFunction(MetadataWorkspace metadataWorkspace, DataSpace dataSpace)
        {
            var function = EdmFunction.Create("usp_SoftDeleteNullFunction", "dbo", dataSpace,
                new EdmFunctionPayload { CommandText = "usp_SoftDeleteNullFunction" }, null);
            return new DbFunctionCommandTree(metadataWorkspace, dataSpace, function,
                TypeUsage.CreateStringTypeUsage(PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.String), false, true),
                null);
        }
    }
