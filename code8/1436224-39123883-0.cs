        static readonly Func<DBContext, int, Post> _get1 =
            CompiledQuery.Compile((DBContext db, int id) => db.Posts.SingleOrDefault(p => p.Id == id));
        static readonly Func<DBContext, int, int, IEnumerable<Post>> _get2 =
            CompiledQuery.Compile((DBContext db, int id0, int id1) => db.Posts.Where(p => p.Id == id0 || p.Id == id1));
        static readonly Func<DBContext, int, int, int, IEnumerable<Post>> _get3 =
            CompiledQuery.Compile((DBContext db, int id0, int id1, int id2) => db.Posts.Where(p => p.Id == id0 || p.Id == id1 || p.Id == id2));
        static readonly Func<DBContext, int, int, int, int, IEnumerable<Post>> _get4 =
            CompiledQuery.Compile((DBContext db, int id0, int id1, int id2, int id3) => db.Posts.Where(p => p.Id == id0 || p.Id == id1 || p.Id == id2 || p.Id == id3));
        static readonly Func<DBContext, int, int, int, int, int, IEnumerable<Post>> _get5 =
            CompiledQuery.Compile((DBContext db, int id0, int id1, int id2, int id3, int id4) => db.Posts.Where(p => p.Id == id0 || p.Id == id1 || p.Id == id2 || p.Id == id3 || p.Id == id4));
        static readonly Func<DBContext, int, int, int, int, int, int, IEnumerable<Post>> _get6 =
            CompiledQuery.Compile((DBContext db, int id0, int id1, int id2, int id3, int id4, int id5) => db.Posts.Where(p => p.Id == id0 || p.Id == id1 || p.Id == id2 || p.Id == id3 || p.Id == id4 || p.Id == id5));
    with
           switch (remaining)
            {
                case 1: results.Add(_get1(Current.DB, ids[offset++])); break;
                case 2: results.AddRange(_get2(Current.DB, ids[offset++], ids[offset++])); break;
                case 3: results.AddRange(_get3(Current.DB, ids[offset++], ids[offset++], ids[offset++])); break;
                case 4: results.AddRange(_get4(Current.DB, ids[offset++], ids[offset++], ids[offset++], ids[offset++])); break;
                case 5: results.AddRange(_get5(Current.DB, ids[offset++], ids[offset++], ids[offset++], ids[offset++], ids[offset++])); break;
                default: results.AddRange(_get6(Current.DB, ids[offset++], ids[offset++], ids[offset++], ids[offset++], ids[offset++], ids[offset++])); break;
            }
    (yes, really)
