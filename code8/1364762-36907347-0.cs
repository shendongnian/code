    ConditionExpression condicion1 = new ConditionExpression();
                condicion1.AttributeName = "name";
                condicion1.Operator = ConditionOperator.NotNull;
    
                FilterExpression filtro = new FilterExpression();
                filtro.Conditions.Add(condicion1);
                filtro.FilterOperator = LogicalOperator.And;
    
                QueryExpression consulta = new QueryExpression("account");
                consulta.Criteria.AddFilter(filtro);
                consulta.ColumnSet = new ColumnSet("name", "telephone1");
    
                EntityCollection resultados = service.RetrieveMultiple(consulta);
    
                foreach (Entity c in resultados.Entities)
                {
                    Console.WriteLine("{0} | {1}", c["name"].ToString(), c["telephone1"].ToString());
                }
                Console.Read();
