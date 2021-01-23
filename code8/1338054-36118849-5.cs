    bool thereAreMoreRows = reader.Read(); // We read the first row, if it exists
                                           // thereAreMoreRows contains true
                                           // if we read a row, or false if
                                           // we didn't
    while(thereAreMoreRows)  // Repeat what is inside the { } while the 
                             // variable thereAreMoreRows is true
                             // Don't enter if it was false
    {
       btn.Text = reader["Field Name"].ToString(); // Assign the current row's "Field Name"
                                                   // converted to a string to the button "btn" text property
       btn2.Text = reader["Field Name"].ToString(); // Assign the current row's "Field Name" 
                                                    // converted to a string to the button "btn2" text property. 
                                                    // Note that this is the same we assigned to btn!
       thereAreMoreRows = reader.Read(); // Advance to the next row, and read it
                                         // or set thereAreMoreRows to false if
                                         // there were no more rows
    } // Repeat until thereAreMoreRows is false
