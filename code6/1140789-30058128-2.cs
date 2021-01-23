    public static List<TE> ConvertList<T, TE>(List<T> list)
        {
            return list.Any() ? list.Select<T, TE>(x => (TE)(dynamic)x).ToList() : new List<TE>();
        }
        public static List<Link> ConvertList1(List<LinkEntity> list)
        {
            return list.Any() ? list.Select<LinkEntity,Link>(x => x).ToList() : new List<Link>();
        }
        public static List<TE> ConvertList3<T, TE>(List<T> list,Func<T,TE> fuc)
        {
            return list.Any() ? list.Select<T, TE>(x => fuc(x)).ToList() : new List<TE>();
        }
