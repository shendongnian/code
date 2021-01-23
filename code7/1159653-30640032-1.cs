    static public void Purchase(string player, int itemID, int herbPrice, int gemPrice)
    {
        OleDbCommand command1 = GenerateConnection(
            "UPDATE ItemPlayerConnection SET Inventory=TRUE WHERE Player=@player AND Item=@itemID");
        command1.Parameters.AddWithValue("@player", player);
        command1.Parameters.AddWithValue("@itemID", itemID);
        OleDbCommand command2 = GenerateConnection(
            "UPDATE Player SET Herbs=(Herbs-@herbPrice) WHERE Owner=@player");
        command2.Parameters.AddWithValue("@herbPrice", herbPrice);
        command2.Parameters.AddWithValue("@player", player);
        OleDbCommand command3 = GenerateConnection(
            "UPDATE Player SET Gems=(Gems-@gemPrice) WHERE Owner=@player");
        command3.Parameters.AddWithValue("@gemPrice", gemPrice);
        command3.Parameters.AddWithValue("@player", player);
        command3.ExecuteNonQuery();
        command2.ExecuteNonQuery();
        command1.ExecuteNonQuery();
    }
