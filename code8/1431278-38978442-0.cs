        public bool injectVBA(String scriptText, String target)
        {
            VBProject found = null;
            Access.Application currApplication = this.currentInstance.Application;
            if (target.Equals("") || scriptText.Equals(""))
                return false;
            foreach (VBProject vb in currApplication.VBE.VBProjects)
            {
                if (currApplication.CurrentDb().Name.Equals(vb.FileName))
                {
                    found = vb;
                    break;
                }
            }
            if (found != null)
            {
                foreach (VBComponent foundComponent in found.VBComponents) 
                {
                    if (foundComponent.Name.Equals(target))
                    {
                        return true;
                    }
                }
                VBComponent module = found.VBComponents.Add(vbext_ComponentType.vbext_ct_StdModule);
                module.Name = target;
                module.CodeModule.AddFromString(scriptText);
                module.Activate();
                //currApplication.DoCmd.OpenModule(target, Type.Missing);
                currApplication.DoCmd.Save(Access.AcObjectType.acModule, target);
                return true;
            }
            else
            {
                return false;
            }
        }
