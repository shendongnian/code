            var newComments = newUsers.SelectMany(user =>
            {
                return user.Comments.Select(comment => new DBCommentLite(user, comment));
            });
            _InsertAll(newComments);
        private void _InsertAll(IEnumerable collection)
        {
            using (var db = new SQLite.SQLiteConnection(_DBName))
            {
                db.InsertAll(collection);
                db.Commit();
            }
        }
