		protected void settingTags() {
			
			using (var connection = new SQLiteConnection (dbPath)) {
				var rowCount = connection.Table<User> ().Count ();
	
				var presentUser = connection.Get<User> (1);
				Log.Info (Tag, "rowCount: " + rowCount.ToString ());
				if (rowCount > 1) {
					Log.Info (Tag, "Database cleared");
					for (int i = rowCount; i > 0-1; i--) {
						//var del = connection.Delete<User> (i);
						var deleted = connection.Query<User> ("DELETE FROM User WHERE ID = ?", i);
						Log.Info (Tag, "for loop i: " + i.ToString ());
						Log.Info (Tag, "Rows deleted: " + deleted.ToString ());
					}
				}
				rowCount = connection.Table<User> ().Count ();
				if (rowCount <= 1) {
					presentUser.Persons = persons;
					connection.Update (presentUser);
					//var Users = connection.Query<User>("UPDATE User SET Persons = ? WHERE ID = 1", persons);
					Log.Info (Tag, "User Data Updated");
				}
			}
		}
