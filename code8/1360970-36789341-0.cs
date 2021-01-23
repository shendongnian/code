        var getAccessor = BuildGetAccessor(p.Name, p.GetGetMethod());
        var setAccessor = BuildSetAccessor(p.Name, p.GetSetMethod());
        // if IsCreatedOnColumn
        cacheProperty.GetValue = (instance) =>
        {
            var value = getAccessor(instance);
            if (value == null)
            {
                value = DateTime.UtcNow;
                setAccessor(instance, value);
            }
            return value;
        };
