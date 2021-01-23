        void Update(MyModel model)
        {
            using (MyContext ctx = new MyContext())
            {
                ctx.DeferredLoadingEnabled = false;
                ctx.MyEntities.Attach(model.OriginalEntity);
                model.OriginalEntity.Value = model.ModifiedEntity.Value;
                ctx.SubmitChanges();
            }
        }
