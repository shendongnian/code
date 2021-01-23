    MyJoinedTable myJoinedTable = null;
    query
       ...
      .JoinQueryOver<MyJoinedTable>(() => myClass.MyJoinedTable, () => myJoinedTable)
      .WhereRestrictionOn(() => myJoined.Field)
          .IsInsensitiveLike("test", MatchMode.Anywhere);
