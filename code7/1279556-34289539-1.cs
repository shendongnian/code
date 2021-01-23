    String sql = @"SELECT Count(TeklifTable.TeklifHazirlayan) AS Basari, 
           EmployeeTable.NAME, 
           EmployeeTable.Surname, 
           Sum(TeklifTable.TeklifTutar)        AS ToplamSatis 
    FROM   EmployeeTable 
           JOIN TeklifTable 
             ON TeklifTable.TeklifHazirlayan = EmployeeTable.EmployeeId 
    GROUP  BY EmployeeTable.NAME, 
              EmployeeTable.Surname";
    EntityDataSourcePersonel.CommandText = sql;
    String whereClause = @"TeklifTable.TeklifTarih >= @baslangicTarihi 
                       AND TeklifTable.TeklifTarih <= @bitisTarihi";
    EntityDataSourcePersonel.Where = whereClause;
    EntityDataSourcePersonel.WhereParameters.Add(new Parameter("baslangicTarihi", TypeCode.DateTime,  Calendar1.SelectedDate));
    EntityDataSourcePersonel.WhereParameters.Add(new Parameter("bitisTarihi", TypeCode.DateTime,  Calendar2.SelectedDate));
