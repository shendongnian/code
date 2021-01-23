    using (var scope = new TransactionScope()) {
        using (var conn = new ReliableSqlConnection("")) {
            using (var ctx = new UniversalModelEntities(new ReliableSqlConnectionWrapper(conn), false)) {
            }
        }
    }
