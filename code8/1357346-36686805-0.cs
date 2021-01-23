    [DataContract]
     public class ProductDetails
            {
            // Apply the DataMemberAttribute to the property.
            [DataMember]
               public int Id { get; set; }
            [DataMember]
               public string ITEM_ITEM_NAME { get; set; }
            [DataMember]
               public DateTime ITEM_ENTR_DATE { get; set; }
            [DataMember]
               public string ITEM_ITEM_STS { get; set; }
            [DataMember]
               public int ITEM_GRP_CODE { get; set; }
            [DataMember]
               public int ITEM_SBGRP_CODE { get; set; }
            [DataMember]
               public int ITEM_SBSBGRP_CODE { get; set; }
            [DataMember]
               public int Picid { get; set; }
            [DataMember]
               public string PicturePath { get; set; }
            }
