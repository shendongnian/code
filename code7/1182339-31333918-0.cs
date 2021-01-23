    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace TestOnly
    {
        public class TestClass
        {
            public void Test()
            {
                Catalog catalog = new Catalog();
            
                //Perform save
                SaveCatalogAction save = new SaveCatalogAction();
                save.Catalog = catalog;
                CatalogManager.Do(save);
                //Perform delete
                DeleteCatalogAction delete = new DeleteCatalogAction();
                delete.Catalog = catalog;
                CatalogManager.Do(delete);
                //Perform update
                UpdateCatalogAction update = new UpdateCatalogAction();
                update.Catalog = catalog;
                CatalogManager.Do(update);
            }
        }
        public class Catalog
        {
            public int Id { get; set; }
            public int Name { get; set; }
        }
        public class CatalogManager
        {
            static public void Do(CatalogAction catalogAction)
            {
                catalogAction.Perform();
            }
        }
        public abstract class CatalogAction
        {
            public Dictionary<int, Catalog> CatalogList = new Dictionary<int, Catalog>();
            public Catalog Catalog { get; set; }
            public abstract void Perform(); //Or you can put the Catalog as parameter
        }
        public class SaveCatalogAction : CatalogAction
        {
            public override void Perform()
            {
                //Do saving with catalog
                if (base.Catalog != null)
                {
                    //Save
                    base.CatalogList.Add(base.Catalog.Id, base.Catalog);
                }
            }
        }
        public class DeleteCatalogAction : CatalogAction
        {
            public override void Perform()
            {
                //Do deleting
                if (base.Catalog != null)
                {
                    //Delete (note no checking just to make it simple)
                    base.CatalogList.Remove(base.Catalog.Id);
                }
            }
        }
        public class UpdateCatalogAction : CatalogAction
        {
            public override void Perform()
            {
                //Do updating
                if (base.Catalog != null)
                {
                    //Update  (note no checking just to make it simple)
                    base.CatalogList[base.Catalog.Id] = base.Catalog;
                }
            }
        }
    }
