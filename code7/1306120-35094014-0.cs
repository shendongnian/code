    {
            String sql = "INSERT INTO item "
                       + "(item_id, invent_id, itemsize, color, curr_price, qoh) "
                       + "VALUES( @ID, @INVID, @SZ,@COL, @PR, @QOH)";
            OdbcCommand Command = new OdbcCommand(sql, db);
            Command.Parameters.Add("@ID", OdbcType.Int).Value = this.Item_ID;
            Command.Parameters.Add("@INVID", OdbcType.Int).Value = this.Invent_id;
            Command.Parameters.Add("@SZ", OdbcType.VarChar).Value = this.Itemsize;
            Command.Parameters.Add("@COL", OdbcType.VarChar).Value = this.Color;
            Command.Parameters.Add("@PR", OdbcType.Double).Value = (double)this.Curr_price;
            Command.Parameters.Add("@QOH", OdbcType.Int).Value = this.Qoh;
            int result = Command.ExecuteNonQuery();  //Returns 1 if successful
            if (result > 0)
                return true;  //Was successful in adding
            else
                return false;  //failed to add
        } //end of AddRow
