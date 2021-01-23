    int age;
    // Check if it is valid
    if(!Int32.TryParse(textYas.Text, out age))
    {
         // It was invalid, consider alerting the user and trying again
    }
    // Otherwise, it was valid and the proper age is stored in age, so use it
    cmd.Parameters.AddWithValue("@uye_yasi",age);
