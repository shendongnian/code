    [Key]
        public string UDetailsId { get; set; }
        [Display(Name = "Your name")]
        public string UName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Date of birth")]
        public DateTime? DOB { get; set; }
        [Display(Name = "my DOB is publich")]
        public bool IsPublic { get; set; }
    
        public string Gender  { get; set; }
        public DateTime? RegesterDate { get; set; }
    
        [Display(Name = "Occupation")]
        public string OccupationDecription { get; set; }
    
        public string UserPhoto { get; set; }
        public int OccupationId { get; set; }
    }}
    
     var entity = new UDetails()
                    {
                        UserPhoto = model.UserPhoto,
                        DOB = model.DOB,
                        IsPublic = model.IsPublic,
                        Gender = model.Gender,
                        OccupationDecription = model.OccupationDecription
    					Email = User.Identity.Name,
    					RegesterDate = DateTime.Now,
    					UDetailsId = User.Identity.GetUserId()
                    };
    
                    db.udetails.Add(entity);
                    db.SaveChanges();
                    return View("index");
     }
