        [Test]
        public void CanSaveAndLoadFacilityMapping()
        {
            object id;
            object id2;
            using (var trans = _session.BeginTransaction())
            {
                id = _session.Save(_facility1);
                id2 = _session.Save(_facility2);
                trans.Commit();
            }
            _session.Clear();
            using (var trans = _session.BeginTransaction())
            {
                var facility = _session.Get<Facility>(id);
                var facility2 = _session.Get<Facility>(id2);
                Assert.AreEqual(facility.Name, _facility1.Name);
                Assert.AreEqual(facility.Owner.Name, _client.Name);
                Assert.AreEqual(facility2.Owner.Name, _client.Name);
                Assert.AreEqual(facility.Owner.Id, facility2.Owner.Id);
                trans.Dispose();
            }
        }
