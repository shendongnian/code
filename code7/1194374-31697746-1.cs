    public static class EntityFactory {
        public static T CreateInstance<T> () {
            var entity = Activator.CreateInstance<T>();
            if (entity is ICryptographerUser) {
                //INJECT INSTANCE HERE
                (entity as ICryptographerUser).Cryptographer = new Cryptographer();
            }
            return entity;
        }      
    }
