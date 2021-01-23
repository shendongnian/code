    public class BaseController : Controller
    {
        public void Validate(BaseModel model)
        {
            bool ITipunique = repository.ISITIPUnique(vmj.NetworkInfo2.FirstOrDefault().IPADDRESS);
            ....
            if ((model.IsIPUnique == true) && (!ITipunique || !TMSipunique))
            {
                ModelState.AddModelError("NetworkInfo2[0].IPAddress", "Error occurred. The Same IP is already assigned.");
            }
            if ((model.IsMACUnique == true) && (!ITmacunique || !TMSmacunique))
            {
                ModelState.AddModelError("NetworkInfo2[0].MACAddress", "Error occurred. The Same MAC Address is already assigned.");
            }
            .... // other common validation  
        }
    }
