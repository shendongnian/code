        public virtual ObjectResult<EnviarHistorial_Result> EnviarHistorial(string p1)
        {
            var p1Parameter = p1 != null ?
                new ObjectParameter("p1", p1) :
                new ObjectParameter("p1", typeof(string));
    
            return this.Database.SqlQuery<EnviarHistorial_Result>("EnviarHistorial", p1);
        }
