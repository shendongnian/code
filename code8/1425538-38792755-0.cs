    context.Table.Where(x = ..Conditions..).Select(s => 
         new { 
              RelatedTableColumn = s.RelatedTable.Column 
              ...
         }).FirstOrDefault();
