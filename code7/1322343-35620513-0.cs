    try
        {
            SqlCommand _myCommand_4 = _con.CreateCommand();
            List<string> sqlParams = new List<string>();
            int i = 0;
            foreach(var value in _Node_Neighbor){
                var name = "@p"  + i++;
                _myCommand_4.Parameters.Add(name,value);
                sqlParams.Add(name);
            }
            string paramNames = string.Join(",", sqlParams);
            _myCommand_4.CommandText = "SELECT COUNT(*) FROM GraphEdges"
                           " WHERE Source_Node IN (" + paramNames + ") " 
                             " AND Target_Node IN (" + paramNames + ")";
            _Mutual_Links = Convert.ToInt32(_myCommand_4.ExecuteScalar());
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
