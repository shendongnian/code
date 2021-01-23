            if (openConnection() == true)
            {
                Cmd = new SqlCommand("Sp_MyFullShowing", Con2);
                //Cmd.CommandText = "Sp_MyFullShowing";
                Cmd.Parameters.AddWithValue("@UserType", UserType);
                Cmd.Parameters.AddWithValue("@UserCode", UserCode);
                Cmd.Parameters.AddWithValue("@DateFrom", DateFrom);
                Cmd.Parameters.AddWithValue("@DateTo", DateTo);
                Cmd.Parameters.AddWithValue("@DealerNo", DealerNo);
                Cmd.Parameters.AddWithValue("@DealerNoCombo", DealerNoCombo);
                Cmd.Parameters.AddWithValue("@VehicleCode", VehicleCode);
                Cmd.Parameters.AddWithValue("@ChassisNo", ChassisNo);
                Cmd.Parameters.AddWithValue("@ReceptionCode", ReceptionCode);
                Cmd.Parameters.AddWithValue("@FactorNo", FactorNo);
                Cmd.Parameters.AddWithValue("@ServiceUserCode", ServiceUserCode);
                Cmd.Parameters.AddWithValue("@PartNo", PartNo);
                Cmd.Parameters.AddWithValue("@CostCenter", CostCenter);
                Cmd.Parameters.AddWithValue("@PartOrService", PartOrService);
                Cmd.Parameters.AddWithValue("@ReceptionType", ReceptionType);
                Cmd.Parameters.AddWithValue("@VehicleType", VehicleType);
                Cmd.Parameters.AddWithValue("@HasWarranty", HasWarranty);
                
                
                Cmd.CommandType = CommandType.StoredProcedure;
                DT = new DataTable();
                Adapter = new SqlDataAdapter(Cmd);
                Adapter.Fill(DT);
                closeConnection();
            }
            return DT;
