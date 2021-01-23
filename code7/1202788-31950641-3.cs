    CarFactory.SetProvider(
        type =>
        {
            switch ( type )
            {
               case A:
                 return _container.Resolve<ICar1>();
               case B:
                 return _container.Resolve<ICar2>();
               ..
        }
    );
