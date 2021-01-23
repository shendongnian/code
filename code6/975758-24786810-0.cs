     [Test]
        public void TestMethod()
        {
            var session = SessionFactory.OpenSession();
            var codiceEvento = "20140630_013325_BA";
            //Step1. Create a new Eventi to be saved with the given code
            using (var trx = session.BeginTransaction())
            {
                var eventi = new Eventi
                {
                    CodiceEvento = codiceEvento
                };
                session.SaveOrUpdate(eventi);
                trx.Commit();
            }
            //Step2. Clear the session so the Eventi object have to be loaded again
            session.Clear();
            using (var trx = session.BeginTransaction())
            {
                var evento = session.Get<Eventi>(codiceEvento);
                //assert the object has no child yet
                evento.EventiDettaglio.Count().Should().Be(0);
                //Step3. Add objects without specify the relationship
                evento.Add(new EventiDettaglioBeneInteressato
                {
                    PrgOrdinamento = 1,
                    CodiceTipoBeneRFI = 1
                });
                evento.Add(new EventiDettaglioBeneInteressato
                {
                    PrgOrdinamento = 2,
                    CodiceTipoBeneRFI = 2
                });
                evento.Add(new EventiDettaglioBeneInteressato
                {
                    PrgOrdinamento = 3,
                    CodiceTipoBeneRFI = 3
                });
                evento.Add(new EventiDettaglioBeneInteressato
                {
                    PrgOrdinamento = 4,
                    CodiceTipoBeneRFI = 4
                });
                //Step4. save the root and then check if all the collection is saved
                session.SaveOrUpdate(evento);
                trx.Commit();
            }
            //Step5. clear again the session to make sure all the things are loaded well from db
            session.Clear();
            using (var trx = session.BeginTransaction())
            {
                var evento = session.Get<Eventi>(codiceEvento);
                //Step6. load the root and then assert the child collection has 4 elements
                evento.EventiDettaglio.Count().Should().Be(4);
                //Step7. delete the root object to repeat the test again and test the cascade
                session.Delete(evento);
                trx.Commit();
            }
            //Step8. check there's no child object for that codiceEvento. the cascade is working!
            using (var trx = session.BeginTransaction())
            {
                session.Query<EventiDettaglioBeneInteressato>()
                    .Count(it => it.Evento.CodiceEvento == codiceEvento)
                    .Should().Be(0);
                trx.Commit();
            }
        }
