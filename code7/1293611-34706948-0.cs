     public void Add<T1, R> ( T1 entity, R virtualEntity, string virtualStr )
            {
                var result = entity.GetType().GetProperty( virtualStr );
                var value = result.GetValue( entity ) as Collection<R>;
                if ( value != null ) value.Add( virtualEntity );
                else
                {
                    result.SetValue( entity, new Collection<R>() );
                    value = result.GetValue( entity ) as Collection<R>;
                    value.Add( virtualEntity );
                }
            }
