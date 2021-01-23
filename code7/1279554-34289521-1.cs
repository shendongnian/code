    EntityDataSourcePersonel.CommandText =
    "SELECT COUNT(TeklifTable.TeklifHazirlayan) AS Basari, EmployeeTable.Name, 
     EmployeeTable.Surname, SUM(TeklifTable.TeklifTutar) AS ToplamSatis FROM 
     EmployeeTable JOIN TeklifTable ON TeklifTable.TeklifHazirlayan = EmployeeTable.EmployeeId 
     WHERE TeklifTable.TeklifTarih >= '" + baslangicTarihi + "' 
     AND TeklifTable.TeklifTarih <= '" + bitisTarihi + "' 
     GROUP BY EmployeeTable.Name,EmployeeTable.Surname";
