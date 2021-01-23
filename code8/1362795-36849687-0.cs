    using System;
    using System.Runtime.Serialization;
    using System.Data.Linq.Mapping;
    public class Class1
    {
        [DataContract]
        [KnownType(typeof(Contract))]
        [KnownType(typeof(Product))]
        [KnownType(typeof(Customer))]
        public abstract class Base
        {
            protected virtual string _sourcePrefix { get; private set; }
            //[DataMember(EmitDefaultValue = false)] // Doesn't seem to do anything
            [IgnoreDataMember] // Only way I could get this to not show up in the WSDL for Base class
            public virtual string Id { get; protected set; }
            [Column(Name = "PRCNGID")] // This is the key for Contracts, foreign key for Customers and Products
            [IgnoreDataMember] // I don't want this to show up in the Base class in the WSDL, only for Contract
            public virtual string ContractId { get; set; }
            [Column(Name = "EFFDT")]
            [DataMember]
            public DateTime? EffectiveDate { get; set; }
            [Column(Name = "EXPDT")]
            [DataMember]
            public DateTime? ExpirationDate { get; set; }
            [Column(Name = "STATUS")]
            [DataMember]
            public Statuses Status { get; set; }
        }
        [Table(Name = "PRPCN10C")]
        [DataContract]
        [KnownType(typeof(Base))]
        public class Contract : Base
        {
            protected override string _sourcePrefix { get { return "PC"; } }
            //[IgnoreDataMember] // Using ContractId field instead for this class' Id
            //public override string Id
            //{
            //    get { return base.Id; }
            //    protected set { base.Id = value; }
            //}
            [Column(Name = "PRCNGID")]
            [DataMember]
            public new string ContractId
            {
                get { return base.ContractId; }
                set { base.ContractId = value; }
            }
            [Column(Name = "PRCNGTYP")]
            [DataMember]
            public Types ContractType { get; set; }
            [Column(Name = "NAME")]
            [DataMember]
            public string Name { get; set; }
            [Column(Name = "ROOTCT#")]
            [DataMember]
            public string RootContractNumber { get; set; }
            [Column(Name = "CMTTYP")]
            [DataMember]
            public string CommitmentType { get; set; }
        }
        [Table(Name = "PRPCN30H")]
        [DataContract]
        public class Customer : Base
        {
            protected override string _sourcePrefix { get { return "PH"; } }
            [Column(Name = "SHPTO#")]
            [DataMember(Name = "CustomerNumber")]
            public new string Id
            {
                get { return base.Id; }
                protected set { base.Id = value; }
            }
        }
        [Table(Name = "PRPCN20D")]
        [DataContract]
        public class Product : Base
        {
            protected override string _sourcePrefix { get { return "PD"; } }
            [Column(Name = "ITEM")]
            [DataMember(Name = "ProductNumber")]
            public new string Id
            {
                get { return base.Id; }
                protected set { base.Id = value; }
            }
        }
    }
