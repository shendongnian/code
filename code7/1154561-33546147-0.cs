var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims,issued,expires,signingKey);
Inserts the claims from the auth'd identity:
i.e if I did this in the OAuth provider:
    IList<Claim> claims = new List<Claim>();
    if (context.UserName.Equals("spencer") && context.UserName.Equals(context.Password))
            {                
                claims.Add(new Claim(ClaimTypes.Name, user.DisplayName));
                claims.Add(new Claim(ClaimTypes.Role, "User"));
            }
    ));
    var claimIdentity = new ClaimsIdentity(claims);
    var ticket = new AuthenticationTicket(claimIdentity, null);
    //Now authed and claims are in my identity context
    context.Validated(ticket);
So now when the JWT is generated those claims are in the token.
You can then decorate your Api Controllers with explicit roles which would then query the "Roles" type in the claimset. If the user doesn't have the role in the role claimset than a 401 is issued:
    
    [Route]
    [Authorize(Roles ="User,Admin")]
    public IHttpActionResult Get()
    {
        return Ok<IEnumerable<Product>>(_products);
    }
    [Route]
    [Authorize(Roles = "Admin")]
    public IHttpActionResult Post(Product product)
    {
        _products.Add(product);
        return Created(string.Empty, product);
    }
So in the above example, if I generate a JWT as me "Spencer" i'm in the users role and the GET would be OK (200) whilst the POST would be Unauthorized (401).
Make sense?
