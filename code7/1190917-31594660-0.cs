    while (objReader.Read())
    {
       peso += objReader.GetDouble(2);
       quantidade += objReader.GetInt32(3);
    }
    arr_list.Add(string.Format("{0}   Peso: {1}   Quantidade: {2}", peixe, peso, quantidade));
                
