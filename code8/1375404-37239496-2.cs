    private static int Count(int OriginalId)
        {
            using (var ctx = new YourDBContext())
            {
                return FindAllSons(OriginalId, ctx);
            }
        }
        private static int FindAllSons(int id, TFSDataContext ctx)
        {
            var res = 1;
            var children = ctx.TableName.Where(x => x.ParentId == id).Select(n => n.Id);
            foreach(var child in children)
            {
                res += FindAllSons(child, ctx);
            }
            return res;
        }
