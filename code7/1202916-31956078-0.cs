    Add Name space in modal class in mvc.
    using System.ComponentModel.DataAnnotations;
    
     public class TelePhones
        {      
            [Required (ErrorMessage  = "MobileNo is required")]
            public long MobileNo { get; set; }
    
            [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
            [DataType(DataType.Date)]
            public string DateOfBirth { get; set; }
    
            [Range(15, 70, ErrorMessage = "Price must be between 15 and 70")]
            public int Age { get; set; }
    }
    client side validation in mvc
    
     <div class="editor-label">
                @Html.LabelFor(model => model.MobileNo)
            </div>
            <div class="editor-field">
                @Html.EditorFor(model => model.MobileNo)
                @Html.ValidationMessageFor(model => model.MobileNo)
            </div> 
            <div class="editor-label">
                @Html.LabelFor(model => model.DateOfBirth)
            </div>
            <div class="editor-field">
                @Html.EditorFor(model => model.DateOfBirth)
                @Html.ValidationMessageFor(model => model.DateOfBirth)       
           </div> 
            <div class="editor-label">
                @Html.LabelFor(model => model.Age)
            </div>
            <div class="editor-field">
                @Html.EditorFor(model => model.Age)
                @Html.ValidationMessageFor(model => model.Age)
            </div>
