            [Column(Name = "ITEM")]
            [DataMember(Name = "ProductNumber")]
            public new string Id
            {
                get { return base.Id; }
                protected set { base.Id = value; }
            }
