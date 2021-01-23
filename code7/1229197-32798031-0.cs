    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using WebApplication1.Models;
    using MongoDB.Bson.Serialization.Attributes;
    namespace WebApplication1.Models
    {
        public class UserModel
        {
        
            [BsonId]
            public ObjectId ID { get; set; }
            [Required]
            [BsonElement]
            public string UserName { get; set; }
            [Required]
            [BsonElement]
            public string Password { get; set; }
            [Required]
            [BsonElement]
            public string Email { get; set; }
            [BsonElement]
            public string PhoneNo { get; set; }
            [BsonElement]
            public string Address { get; set; }
        }
    }
