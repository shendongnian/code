    for(int i = 1; i < avgTimeArray.length; i++){
    sc = new     MySqlCommand("Update tbName set AvgTime = @AvgTime where PatternId = @PatternID", msc);
    sc.Parameters.Add(new ObjectParameter("AvgTime", avgTimeArray[i].ToString())); 
    sc.Parameters.Add(new ObjectParameter("PatternID", i.ToString())); 
    sc.ExecuteNonQuery();}
