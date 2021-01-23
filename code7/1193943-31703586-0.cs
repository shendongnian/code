	private void FillInForeignKeyOperations(IEnumerable<MigrationOperation> operations, XDocument targetModel)
	{
		DebugCheck.NotNull(operations);
		DebugCheck.NotNull(targetModel);
		foreach (var foreignKeyOperation
			in operations.OfType<AddForeignKeyOperation>()
						 .Where(fk => fk.PrincipalTable != null && !fk.PrincipalColumns.Any()))
		{
			var principalTable = GetStandardizedTableName(foreignKeyOperation.PrincipalTable);
			var entitySetName
				= (from es in targetModel.Descendants(EdmXNames.Ssdl.EntitySetNames)
				   where _modelDiffer.GetQualifiedTableName(es.TableAttribute(), es.SchemaAttribute())
									 .EqualsIgnoreCase(principalTable)
				   select es.NameAttribute()).SingleOrDefault();
			if (entitySetName != null) //ERROR SOURCE IS BELOW
			{
				var entityTypeElement
					= targetModel.Descendants(EdmXNames.Ssdl.EntityTypeNames)
								 .Single(et => et.NameAttribute().EqualsIgnoreCase(entitySetName)); 
				entityTypeElement
					.Descendants(EdmXNames.Ssdl.PropertyRefNames).Each(
						pr => foreignKeyOperation.PrincipalColumns.Add(pr.NameAttribute()));
			}
			else
			{
				// try and find the table in the current list of ops
				var table
					= operations
						.OfType<CreateTableOperation>()
						.SingleOrDefault(ct => GetStandardizedTableName(ct.Name).EqualsIgnoreCase(principalTable));
				if ((table != null)
					&& (table.PrimaryKey != null))
				{
					table.PrimaryKey.Columns.Each(c => foreignKeyOperation.PrincipalColumns.Add(c));
				}
				else
				{
					throw Error.PartialFkOperation(
						foreignKeyOperation.DependentTable, foreignKeyOperation.DependentColumns.Join());
				}
			}
		}
	}
