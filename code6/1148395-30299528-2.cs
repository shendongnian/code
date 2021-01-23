    public class MyProductionCode{
        private IEntityManagerWrapper _entityManager;
        public MyProductionCode(IEntityManagerWrapper entityManager) {
            _entityManager = entityManager;
        }
        public void DoStuff() {
            PersonaEntityManager pem = _entityManager.GetEntityManager<PersonaEntityManager>(EntityManager.EntityManagerInstanceType.NewInstance);
            var response = pem.UpdatePersona(new PersonaUpdateRequestData());
        }
    }
