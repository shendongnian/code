			while (reader.Read())
			{
				var cin = reader.GetInt64(0);
				var nom = reader.GetString(1);
				var prenom = reader.GetString(2);
				var addressPersonel = reader.GetString(3);
				var numTel = reader.GetDouble(4);
				var mail = reader.GetString(5);
				var mobile = reader.GetDouble(6);
				var cpGerant = reader.GetInt32(7);
				var villeGerant = reader.GetString(8);
				var dateCin = reader.GetDateTime(9);
				gerer.Add(new gerant(cin,
					nom,
					prenom,
					addressPersonel,
					numTel,
					mail,
					mobile,
					cpGerant,
					villeGerant,
					dateCin)
					);
			}
