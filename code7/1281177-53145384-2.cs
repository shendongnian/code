            public List<MyModelObject> GetMyModelObjectList(IEnumerable<DataSnapshot> enumerableSnapshot)
        {
            List<MyModelObject> list = new List<MyModelObject>();
            foreach (var item in enumerableSnapshot)
            {
                list.Add(ObjectExtensions.DataSnapshotToObject<MyModelObject>(item.Children?.ToEnumerable<DataSnapshot>()));
            }
            return list;
        }
