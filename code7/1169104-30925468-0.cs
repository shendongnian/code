        public int Discordo { get; set; }
        public int Rever { get; set; }
        public int Anotacao { get; set; }
        public int Realizada { set; get; }
        public int Ativo { set; get; }
        public int IdEspecialidade { get; set; }
        public string NomeEspecialidade { set; get; }
        public string DescricaoAlternativa { set; get; }
        public int IdQuestao { get { return (this as IQuestao).Id; } set { (this as IQuestao).Id = value; } }
        public int IdTipoExercicio { get { return (this as IQuestao).IdTipoExercicio; } set { (this as IQuestao).IdTipoExercicio = value; } }
        public int Correta { get { return (this as IQuestao).Correta; } set { (this as IQuestao).Correta = value; } }
        public int Ano { get { return (this as IExercicio).Ano; } set { (this as IExercicio).Ano = value; } }
        public int IdExercicio { get { return (this as IExercicio).Id; } set { (this as IExercicio).Id = value; } }
        public string NomeExercicio { get { return (this as IExercicio).Nome; } set { (this as IExercicio).Nome = value; } }
        public string Regiao { get { return (this as IExercicio).txtRegiao; } set { (this as IExercicio).txtRegiao = value; } }
        public string EnunciadoQuestao { get { return (this as IQuestao).EnunciadoQuestao; } set { (this as IQuestao).EnunciadoQuestao = value; } }
        public string GuidQuestao { get { return (this as IQuestao).GuidQuestao; } set { (this as IQuestao).GuidQuestao = value; } }
        public int IQuestao.Id { get; set; }
        string IQuestao.EnunciadoQuestao { get; set; }
        string IQuestao.ExercicioTipo { get; set; }
        List<Especialidade> IQuestao.Especialidades { get; set; }
