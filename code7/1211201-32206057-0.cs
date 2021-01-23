    for(int i = 0; i < avgTimeArray.length; i++){
    sc = new     MySqlCommand("Update tbName set AvgTime=@AvgTime where   PatternId=@PatternID", msc);
    contactQuery.Parameters.Add(new ObjectParameter("AvgTime", avgTimeArray[i].ToString()));
    contactQuery.Parameters.Add(new ObjectParameter("PatternID", i +1 .ToString())); //this will fix the zero based index for the array, since patternID will always want be be one higher than the array index.
    sc.ExecuteNonQuery();}
