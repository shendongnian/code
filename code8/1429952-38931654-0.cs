    var objList = new List<PodaciAnaliza>();
    
    
    int counter = 1;
    foreach (DataGridViewRow row in glProstor.Rows)
    {
        if (counter != glProstor.Rows.Count)
        {
            var podaciAnaliza = new PodaciAnaliza();
            podaciAnaliza.Sesija = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            
            //add if not null  
            podaciAnaliza.Spin = row.Cells["brojSpina"].Value.ToString();
            podaciAnaliza.EditK1 = row.Cells["editKontra1"].Value.ToString();
            podaciAnaliza.EditI1 = row.Cells["editIsta1"].Value.ToString();
            podaciAnaliza.EditK2 = row.Cells["editKontra2"].Value.ToString();                 
            podaciAnaliza.EditI2 = row.Cells["editIsta2"].Value.ToString();
    
            objList.Add(podaciAnaliza);
            counter++;
        }
    
    }//end of foreach
    
    //Seralized list:
    var list = JsonConvert.SeralizeObject(objList);
