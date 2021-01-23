    EntityDataSourcePersonel.CommandText =
    "SELECT COUNT(TeklifTable.TeklifHazirlayan) AS Basari, EmployeeTable.Name, 
    EmployeeTable.Surname, SUM(TeklifTable.TeklifTutar) AS ToplamSatis FROM 
    EmployeeTable JOIN TeklifTable ON TeklifTable.TeklifHazirlayan = EmployeeTable.EmployeeId 
    WHERE TeklifTable.TeklifTarih >= '" + baslangicTarihi.ToString("yyyy-MM-dd") + "' 
    AND TeklifTable.TeklifTarih <= '" + bitisTarihi.ToString("yyyy-MM-dd") + "' 
    GROUP BY EmployeeTable.Name,EmployeeTable.Surname";
