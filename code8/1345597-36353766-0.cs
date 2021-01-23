    //Instead of storing it in a string, we use a list of strings
    nacinUnosa = List<string>();
    //Just check each checkbox once...
    if (checkBox1.Checked)
        nacinUnosa.push("1");
    if (checkBox2.Checked)
        nacinUnosa.push("2");
    if (checkBox3.Checked)
        nacinUnosa.push("3");
    if (checkBox4.Checked)
        nacinUnosa.push("4");
    //Now we have a full list with all the active checkboxes.. For the query, we can do something like:
    var query = "SELECT * FROM Clothes WHERE ";
    for (var i = 0; i < nacinUnosa.length; i++) {
        //Create your sql query code here.. Something like:
        if (i != 0) 
           query += " OR " ;
        nacinUnosa = " + nacinUnosa[i] " ;
    }
    
