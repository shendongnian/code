    string userPWD = "Alpha@1Mega";    
    await userManager.CreateAsync(userAdmin, userPWD);
    var user =  await userManager.FindByNameAsync("TrueMan");
    if(!(await userManager.IsInRoleAsync(user, "Admin")))
        await userManager.AddToRoleAsync(user, "Admin");
