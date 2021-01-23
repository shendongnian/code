c#
[ForeignKey("User")]<br/>
public string UserId { get; set; }<br/>
public virtual ApplicationUser User { get; set; }
When I add the above lines to the class, and then migrate and update the DB,<br/>
 I get ApplicationUser Table created !
 
