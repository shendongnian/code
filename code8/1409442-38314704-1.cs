     [RequiredIfISaySo(3, ErrorMessage = "NAME REQUIRED")]
        public string Name { get; set; }
        [RequiredIfISaySo(2, ErrorMessage = "PHONE REQUIRED")]
        public string Phone { get; set; }
        [RequiredIfISaySo(1, ErrorMessage ="ADDRESS REQUIRED")]
        public string Address { get; set; }
