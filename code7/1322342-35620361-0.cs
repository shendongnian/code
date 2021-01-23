    using (SqlDataReader _myReader_2 = _myCommand_3.ExecuteReader())
            {
                _Node_Neighbor.Clear();
                while (_myReader_2.Read())
                {
                    _Node_Neighbor.Add(Convert.ToInt32(_myReader_2["Target_Node"]));
                }
                _myReader_2.Close();
                //Here I have to pass this _Node_Neighbor i.e. of type List<int> to another  
                //SQL Server query as:
                try
                {
                    var query = @"SELECT COUNT(*) FROM GraphEdges
                    WHERE Source_Node IN
    
                    (##Source_Node)
                    AND Target_Node IN 
                    (##Target_Node)";
                    var sourceNode = "";
                    foreach (var item in _Node_Neighbor)
                    {
                        sourceNode += item + ",";
                    }
                    sourceNode = sourceNode.TrimEnd(',');
                    var targetNode = "";
                    foreach (var item in _Node_Neighbor)
                    {
                        targetNode += item + ",";
                    }
                    targetNode = targetNode.TrimEnd(',');
                    query = query.Replace("##Source_Node", sourceNode).Replace("##Target_Node", targetNode);
                    SqlCommand _myCommand_4 = _con.CreateCommand();
                    _myCommand_4.CommandText = @"SELECT COUNT(*) FROM GraphEdges
                                         WHERE Source_Node IN @Source_Node 
                                         AND Target_Node IN @Target_Node";
                    _Mutual_Links = Convert.ToInt32(_myCommand_4.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
