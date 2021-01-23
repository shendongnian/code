        using (new scope = new TransactionScope())
        {
            var newItem1 = new SomeEntity { Id = 4, Remark = "Test 2" };
            var newItem2 = new SomeEntity { Id = 5, Remark = "Test 2" };
            var x = new List<SomeEntity> { newItem1, newItem2 };
            _testTvp.SaveSomeEntities(x);
            var result = _test.GetSomeEntity(4);
            Assert.AreEqual(newItem1.Remark, result.Remark);
            result = _test.GetSomeEntity(5);
            Assert.AreEqual(newItem2.Remark, result.Remark);
           
            //either of the two following:
            Transaction.Current.Rollback();
            scope.Dispose();
        }
