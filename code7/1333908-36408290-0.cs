        this.geometryUserType = SpatialDialect.LastInstantiated.CreateGeometryUserType();
        ...
        public System.Type ReturnedType
        {
            get { return this.geometryUserType.ReturnedType; }
        }
