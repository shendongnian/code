    SqlCommand com = new SqlCommand("INSERT INTO menudatas [mainMenuNum] values (@mainMenuNum)", conn);
    
    // define your parameter ONCE before the loop
    com.Parameters.Add("@mainMenuNum", SqlDbType.VarChar, 20);   // adapt the datatype to match your situation
    for(int x = 0; x<textboxValues.Count(); x++)
    { 
        // only assign the VALUE to the parameter repeatedly, in the loop
        com.Parameters["@mainMenuNum"].Value = textboxValues[x]);
        com.ExecuteNonQuery();
    }
    SqlCommand com1 = new SqlCommand("INSERT INTO menudatas [mainMenuText] values (@mainMenuText)" , conn);
    // define your parameter ONCE before the loop - and add it to the **correct** SqlCommand "com1" - not "com" ....
    com1.Parameters.Add("@mainMenuText", SqlDbType.VarChar, 100);  // adapt the datatype to match your situation
    for (int y = 0; y < textboxValues1.Count(); y++)
    {  
        // only assign the VALUE to the parameter repeatedly, in the loop
        com.Parameters["@mainMenuText"].Value = textboxValues1[y]);
        com1.ExecuteNonQuery();
        container.Visible = false;
    }
    conn.Close();
}
