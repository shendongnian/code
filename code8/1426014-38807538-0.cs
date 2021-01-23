     [DisplayName("Request By")]
     public string UserId { get; set; }
    
        
     [DisplayName("Assign To")]
     [Remote("Validate", HttpMethod="Post", AdditionalFields="UserId", ErrorMessage = "Should not be same")]
           public string ManagerId { get; set; }
