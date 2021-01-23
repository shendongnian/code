        public void DeleteUserGroup(List<MY_GROUPS> ug)
        {
            using (var context = new MYConn())
            {
                context.MY_GROUPS.RemoveRange(ug);
                context.SaveChanges();
            }
        }
