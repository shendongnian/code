    var query = from table in tablename 
                group by new { table.Assigned_Individual, table.Data_Output_Type, table.assigned_group }
                into grp
                select new 
                {
                     grp.Key.AssignedIndividual,
                     grp.Key.Data_Output_Type,
                     grp.Key.assigned_group,
                     Count = grp.Count()
                }; 
