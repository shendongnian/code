     StringBuilder sb = new StringBuilder();
     for (int i = 0, offset = 5; i < num_meters; i++, offset += 25)
     {   
         .....
         sb.Append(Data + "\t");
     }
     // Remove the last tab
     if(sb.Length > 0) sb.Length--; 
     string filename = (pathname + "MeterLogDataON_" + System.DateTime.Now.ToString("dd-MM-yyyy") + ".csv"
     File.WriteAllText(filename, sb.ToString());
